/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    // load Grunt plugins from NPM
    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-watch');

    // configure plugins
    grunt.initConfig({
        clean: ["wwwroot/lib/*", "temp/"],
        concat: {
            all: {
                src: ['App/QuikOptApp.js', 'App/**/*.js'],
                dest: 'temp/QuikOptAppCombined.js'
            }
        },
        jshint: {
            files: ['temp/*.js'],
            options: {
                '-W069': false,
            }
        },
        uglify: {
            all: {
                src: ['temp/QuikOptAppCombined.js'],
                dest: 'wwwroot/lib/QuikOptApp.min.js'
            }
        },
        watch: {
            files: ["App/*.js"],
            tasks: ["all"]
        }
    });

    grunt.registerTask("all", ['clean', 'concat', 'jshint', 'uglify', 'watch']);
};