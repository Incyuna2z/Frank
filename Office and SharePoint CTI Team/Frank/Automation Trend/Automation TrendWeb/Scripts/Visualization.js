var charttemp ={};
var visualization = (function () {
    'use strict';

    var visualization = {};

    // Generates and returns an Office.TableData object with sample data.
    visualization.generateSampleData = function () {
        var sampleHeaders = [['Build No', 'Initial', 'Final','RunID','OS','OS Lang','VS Lang','test query']];
        var sampleRows = [
            [30625.00, 77, 94.86,3200968,'Win Server 2008 R2 SP1','ENU','ENU',687858],
            [30707.00, 77.21, 86.0, 3220281, 'Win Server 2008 R2 SP1', 'ENU', 'ENU', 687858],
            [30714.00, 44.09, 87.80, 3232089, 'Win Server 2008 R2 SP1', 'ENU', 'ENU', 687858],
            [30721.00, 83.00, 92.89, 3242771, 'Win Server 2008 R2 SP1', 'ENU', 'ENU', 687858],
            [30722.00, 85.60, 93.00, 3249408, 'Win Server 2008 R2 SP1', 'ENU', 'ENU', 687858],
            [30723.00, 76.54, 93.00, 3382069, 'Win Server 2008 R2 SP1', 'ENU', 'ENU', 687858],
            [30804.00, 59.13, 92.46, 3439463, 'Win Server 2008 R2 SP1', 'ENU', 'ENU', 687858],
        ];
        return new Office.TableData(sampleRows, sampleHeaders);
    }

    visualization.display = function ($element, data, errorHandler) {

        var build = new Array();

        if ((data.rows.length < 1) || (data.rows[0].length < 2)) {
            errorHandler('The data range must contain at least 1 row and at least 2 columns.');
            return;
        }

        for (var i = 0; i < data.rows.length; i++) {
            build.push(data.rows[i][0]);
        }

        charttemp = {
            title: {
                text: 'Automation Passing Rate',
                x: -20
            },
            credits: {
                enabled: false
            },
            xAxis: {
                categories: build,
                crosshair: true
            },
            yAxis: {
                min: 0,
                max: 100,
                title: {
                    text: 'Pasing Rate (%)'
                },
                plotLines: [{
                    value: 0,
                    width: 1,
                    color: '#2828FF'
                }]
            },
            tooltip: {
                valueSuffix: '%'
            },
            legend: {
                layout: 'vertical',
                align: 'right',
                verticalAlign: 'middle',
                borderWidth: 0
            },
            series: [{
                name: 'Initial',
                color: "#28FF28",
                data: (function () {
                    var init = new Array;
                    var initpr;
                    for (initpr = 0; initpr < data.rows.length; initpr++) {
                        init.push(data.rows[initpr][1]);
                    }
                    return init;
                })()
            }, {
                name: 'Final',
                data: (function () {
                    var final = new Array;
                    var finalpr;
                    for (finalpr = 0; finalpr < data.rows.length; finalpr++) {
                        final.push(data.rows[finalpr][2]);
                    }
                    final.push();
                    return final;
                })()
            }]
        }

        $('#container').highcharts(charttemp);

        //Change the branch info,then hide the form
        $("select").change(function () {
            $("select :selected").each(function () {
                var Ver = $(this).text();
                var title = {
                    text: Ver,
                    style:{
                        color: '#285abd',
                        fontSize: '16px',
                    },              
                };
                $("form").hide();
                var chart = $("#container").highcharts();
                chart.setTitle({ text: 'Automation Passing Rate' }, title);
            })
        })
    };
            return visualization;
})();
