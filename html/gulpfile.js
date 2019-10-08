// Gulp.js configuration
var
  // modules
  //for js
  connect = require('gulp-connect');
  concat = require('gulp-concat'),
  deporder = require('gulp-deporder'),
  stripdebug = require('gulp-strip-debug'),
  uglify = require('gulp-uglify'),
  gulp = require('gulp'),
  newer = require('gulp-newer'),
  //for images
  imagemin = require('gulp-imagemin'),
  //for html minifies
  htmlclean = require('gulp-htmlclean'),
  //for css
  sass = require('gulp-sass'),
  postcss = require('gulp-postcss'),
  assets = require('postcss-assets'),
  autoprefixer = require('autoprefixer'),
  mqpacker = require('css-mqpacker'),
  cssnano = require('cssnano'),
  //for browers
  livereload = require('gulp-livereload'),
  // development mode?
  // devBuild = (process.env.NODE_ENV !== 'production'),

  // folders
  folder = {
    src: 'src/',
    build: 'build/'
  }

  // server

  gulp.task('connect', function() {
    connect.server({
      root: folder.build,
      livereload: true
    });
  });

  // image processing
  gulp.task('images', function() {
    var out = folder.build + 'images/';
    return gulp.src(folder.src + 'images/**/*')
      .pipe(newer(out))
      .pipe(imagemin({ optimizationLevel: 5 }))
      .pipe(gulp.dest(out));
  });

  // HTML processing
  gulp.task('html', ['images'], function() {
    var
      out = folder.build + 'html/',
      page = gulp.src(folder.src + 'html/**/*')
        .pipe(newer(out));

    // minify production code
    // if (!devBuild) {
    //   page = page.pipe(htmlclean());
    // }

    return page.pipe(gulp.dest(out))
            .pipe(connect.reload());
  });

  // JavaScript processing
  gulp.task('js', function() {

    var jsbuild = gulp.src(folder.src + 'js/**/*')
      .pipe(deporder())
      .pipe(concat('main.js'));

    // {
    //   jsbuild = jsbuild
    //     .pipe(stripdebug())
    //     .pipe(uglify());
    // }

    return jsbuild.pipe(stripdebug())
      .pipe(uglify())
      .pipe(gulp.dest(folder.build + 'js/'));

  });

  // CSS processing
  gulp.task('css', ['images'], function() {

    var postCssOpts = [
    assets({ loadPaths: ['images/'] }),
    autoprefixer({ browsers: ['last 2 versions', '> 2%'] }),
    mqpacker
    ];

    // if (!devBuild) {
    //   postCssOpts.push(cssnano);
    // }

    return gulp.src(folder.src + 'scss/style.scss')
      .pipe(sass({
        outputStyle: 'nested',
        imagePath: 'images/',
        precision: 3,
        errLogToConsole: true
      }))
      .pipe(postcss(postCssOpts))
      .pipe(gulp.dest(folder.build + 'css/'))
      .pipe(connect.reload());

  });

  // run all tasks
  gulp.task('run', ['html', 'css']);

  // watch for changes
  gulp.task('watch', function() {
    livereload.listen(35732);
    // image changes
    gulp.watch(folder.src + 'images/**/*', ['images']);

    // html changes
    gulp.watch(folder.src + 'html/**/*', ['html']);

    //javascript changes
    // gulp.watch(folder.src + 'js/**/*', ['js']);

    // css changes
    gulp.watch(folder.src + 'scss/**/*', ['css']);

  });


  // default task
  gulp.task('default', ['connect', 'run', 'watch']);

;
