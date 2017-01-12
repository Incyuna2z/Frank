
/// <reference path="../../Scripts/Visualization.js" />
(function () {
    'use strict';
    $(document).ready(function () {
        $("#setting-theme-button").click(function () {
            $("#setting-theme").load("../SettingPane/Settingpane.html");

        });

        function ResetOptions() {
            debugger
            //Get rid of all chart context,then set the specific theme
            var defaultOptions = Highcharts.getOptions();
            for (var prop in defaultOptions) {
                if (typeof defaultOptions[prop] !== 'function') delete defaultOptions[prop];
            }
        }
        $(document).on('click','#dark-blue',function () {
            var chart = $("#container").highcharts();
            if (chart) {
                Highcharts.setOptions(themeArr[1]);
                $('#container').highcharts(charttemp);
            }
        });

        $(document).on('click', '#dark-green', function () {
            var chart = $("#container").highcharts();
            if (chart) {
                Highcharts.setOptions(themeArr[2]);
                $('#container').highcharts(charttemp);
            }
        });

        $(document).on('click', '#dark-unica', function () {
            var chart = $("#container").highcharts();
            if (chart) {
                Highcharts.setOptions(themeArr[3]);
                $('#container').highcharts(charttemp);
            }
        });

        $(document).on('click', '#gray', function () {
            var chart = $("#container").highcharts();
            if (chart) {
                Highcharts.setOptions(themeArr[4]);
                $('#container').highcharts(charttemp);
            }
        });

        $(document).on('click', '#grid', function () {
            var chart = $("#container").highcharts();
            if (chart) {
                Highcharts.setOptions(themeArr[5]);
                $('#container').highcharts(charttemp);
            }
        });

        $(document).on('click', '#grid-light', function () {
            var chart = $("#container").highcharts();
            if (chart) {
                Highcharts.setOptions(themeArr[6]);
                $('#container').highcharts(charttemp);
            }
        });
    });
})();