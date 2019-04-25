var _max = 128;
var _escape = 4;

addEventListener("message", onMessage, false);

function onMessage (e) {
    // Extract input values from e.data
    var id = e.data.id;
    var bitmap = e.data.bitmap;
    var rmin = e.data.rmin;
    var rmax = e.data.rmax;
    var imin = e.data.imin;
    var imax = e.data.imax;

    var h = _max >> 1; // Divide max by 2
    var q = _max >> 2; // Divide max by 4

    // Compute increments for real and imaginary components
    var dr = (rmax - rmin) / (bitmap.width - 1);
    var di = (imax - imin) / (bitmap.height - 1);

    // Check each pixel for inclusion in the Mandelbrot set
    for (x = 0; x < bitmap.width; x++) {
        var cr = rmin + (x * dr);

        for (y = 0; y < bitmap.height; y++) {
            var ci = imin + (y * di);
            var zr = cr;
            var zi = ci;
            var count = 0;

            while (count < _max) {
                var zr2 = zr * zr;
                var zi2 = zi * zi;

                if (zr2 + zi2 > _escape) {
                    setPixel(bitmap, x, y, 0xff, (count * 255) / _max, ((count % h) * 255) / h, ((count % q) * 255) / q);
                    break;
                }

                zi = ci + (2 * zr * zi);
                zr = cr + zr2 - zi2;
                count++;
            }

            if (count == _max)
                setPixel(bitmap, x, y, 0xff, 0, 0, 0);
        }
    }

    // Post the populated imageData object along with the
    // quadrant ID back to the UI thread
    postMessage({ "id": id, "bitmap": bitmap });
}

function setPixel(bitmap, x, y, a, r, g, b) {
    var index = (x + y * bitmap.width) << 2;
    bitmap.data[index + 0] = r;
    bitmap.data[index + 1] = g;
    bitmap.data[index + 2] = b;
    bitmap.data[index + 3] = a;
}