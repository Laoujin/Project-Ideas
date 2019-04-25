'use strict';

//browser-sync start --server --files dist
//http://localhost:3000/dist/

var gulp = require('gulp');
var plumber = require('gulp-plumber');
var jade = require('gulp-jade');
var browserSync = require('browser-sync').create();

gulp.task('jade', function() {
  gulp.src('./jade/pages/*.jade')
  .pipe(plumber())
  .pipe(jade({
    locals: require('./jade/config.json'),
    pretty: true
  }))
  .pipe(gulp.dest('./dist/'));
});

gulp.task('serve', ['jade'], function() {
  browserSync({
    notify: false,
    port: 9000,
    server: {
      baseDir: ['dist'],
      routes: {
        '/': 'dist'
      }
    }
  });

  gulp.watch([
    'dist/*.html',
    //'dist/scripts/**/*.js',
    //'dist/images/**/*',
    //'.tmp/fonts/**/*'
  ]).on('change', reload);

  //gulp.watch('app/styles/**/*.scss', ['styles']);
  //gulp.watch('app/fonts/**/*', ['fonts']);
  //gulp.watch('bower.json', ['wiredep', 'fonts']);
});

gulp.task('watch', function() {
  gulp.watch('./jade/**/*', ['jade']);
});

gulp.task('default', ['jade', 'watch']);
gulp.task('release', ['jade']);


// TODO: add sass later
//c:\code\test\yoman\
//require-dir




// var gulp = require('gulp-help')(require('gulp'));

// var rubySass = require('gulp-ruby-sass');

// var sourcemaps = require('gulp-sourcemaps');
// var postcss = require('gulp-postcss');
// var plumber = require('gulp-plumber');

// var autoprefixer = require('autoprefixer');

// var config = require('./../config.js');
// var reload = require('./browserSync.js').reload;
// var handleError = require('./../utils/handleError.js');

// // Compile scss using ruby sass

// gulp.task('styles', 'Compile Sass to CSS', function () {
//   return rubySass(config.styles.src, config.styles.sassCfg)
//     .on('error', handleError)
//     .pipe(postcss([
//       autoprefixer(config.styles.autoprefixerCfg)
//     ]))
//     .pipe(sourcemaps.write())
//     .pipe(gulp.dest(config.styles.dest))
//     .pipe(reload({stream:true}));
// });