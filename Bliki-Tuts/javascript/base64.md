import { Injectable } from "@angular/core";
import "../rxjs-operators";
import { RelativeUrlTemplates, Rest } from "./index";
 
@Injectable()
export class ReportingService {
    constructor(private readonly rest: Rest) {
    }
 
    alwin(): void {
        const fileName = `Alwin_${moment().format("YYYY-MM-DD")}.xlsx`;
        this.rest.get(RelativeUrlTemplates.getAlwinReport)
            .toPromise()
            .then(report => {
                const contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                const blob = ReportingService.b64ToBlob(report, contentType);
                const blobUrl = URL.createObjectURL(blob);
 
                const link = document.createElement("a");
                link.download = fileName;
                //link.href = `data:application/octet-stream;base64,${report}`;
                link.href = blobUrl;
                link.click();
            });
    }
 
    private static b64ToBlob(b64Data, contentType = "", sliceSize = 512) {
        const byteCharacters = atob(b64Data);
        const byteArrays = [];
 
        for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
            const slice = byteCharacters.slice(offset, offset + sliceSize);
            const byteNumbers = new Array(slice.length);
            for (let i = 0; i < slice.length; i++) {
                byteNumbers[i] = slice.charCodeAt(i);
            }
 
            const byteArray = new Uint8Array(byteNumbers);
            byteArrays.push(byteArray);
        }
 
        const blob = new Blob(byteArrays, { type: contentType });
        return blob;
    }
}