/// <reference path="../App.js" />
/// <reference path="../Visualization.js" />

(function () {
    'use strict';

    // The Office.initialize function must be defined for each page in your app.
    Office.initialize = function (reason) {
        $(document).ready(function () {
            app.initialize();

            displayDataOrRedirect();
        });
    };

    // Checks if a binding exists, and either displays the visualization,
    //        or redirects to the DataBinding page.
    function displayDataOrRedirect() {
        Office.context.document.bindings.getByIdAsync(
            app.bindingID,
            function (result) {
                if (result.status === Office.AsyncResultStatus.Succeeded) {
                    var binding = result.value;
                    displayDataForBinding(binding);
                    binding.addHandlerAsync(
                        Office.EventType.BindingDataChanged,
                        function () { displayDataForBinding(binding); }
                    );
                } else {
                    window.location.href = '../DataBinding/DataBinding.html';
                }
            });
    }

    // Queries the binding for its data, then delegates to the visualization script.
    function displayDataForBinding(binding) {
        binding.getDataAsync(
            {
                coercionType: Office.CoercionType.Table,
                valueFormat: Office.ValueFormat.Unformatted,
                filterType: Office.FilterType.OnlyVisible
            },
            function (result) {
                if (result.status === Office.AsyncResultStatus.Succeeded) {
                    visualization.display($('#data-display'), result.value, showError);
                } else {
                    showError('Could not read data.');
                }
            }
        );

        function showError(message) {
            $('#data-display').html(
                '<div class="notice">' +
                '    <h3>Error</h3>' + $('<p/>', { text: message })[0].outerHTML +
                '    <a href="../DataBinding/DataBinding.html">' +
                '        <b>Bind to a different data range?</b>' +
                '    </a>' +
                '</div>');
        }
    }

})();
