/// <reference path="../App.js" />
/// <reference path="../../Scripts/Visualization.js" />

(function () {
    'use strict';

    // The Office.initialize function must be defined for each page in your app.
    Office.initialize = function (reason) {
        $(document).ready(function () {
            app.initialize();

            $('#bind-to-existing-data').click(bindToExistingData);

            if (dataInsertionSupported()) {
                $('#insert-sample-data').show();
                $('#insert-sample-data').click(insertSampleData);
            }
        });
    };

    // Binds the visualization to existing data.
    function bindToExistingData() {
        Office.context.document.bindings.addFromPromptAsync(
            Office.BindingType.Table,
            { id: app.bindingID, sampleData: visualization.generateSampleData() },
            function (result) {
                if (result.status === Office.AsyncResultStatus.Succeeded) {
                    window.location.href = '../Home/Home.html';
                } else {
                    app.showNotification(result.error.name, result.error.message);
                }
            }
        );
    }

    // Checks whether the current application supports setting selected data.
    function dataInsertionSupported() {
        return Office.context.document.setSelectedDataAsync &&
            (Office.context.document.bindings &&
            Office.context.document.bindings.addFromSelectionAsync);
    }

    // Inserts sample data into the current selection (if supported).
    function insertSampleData() {
        Office.context.document.setSelectedDataAsync(visualization.generateSampleData(),
            function (result) {
                if (result.status === Office.AsyncResultStatus.Succeeded) {
                    Office.context.document.bindings.addFromSelectionAsync(
                        Office.BindingType.Table, { id: app.bindingID },
                        function (result) {
                            if (result.status === Office.AsyncResultStatus.Succeeded) {
                                window.location.href = '../Home/Home.html';
                            } else {
                                app.showNotification(result.error.name, result.error.message);
                            }
                        }
                    );
                } else {
                    app.showNotification(result.error.name, result.error.message);
                }
            }
        );
    }

})();
