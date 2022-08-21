$(document).ready(function () {
    function customOpen(selector) {
        var $filterBody = $(selector);
        $filterBody.removeClass('collapse');
        setTimeout(function () {
            $filterBody.addClass('collapse show');
        }, 1000);
    }

    $('#global-search-header-panel').focus(function () {
        customOpen('#filterBody');
    });

    $('#global-search-header-panel').on('input', function () {
        var textLength = $(this).val().length;
        if (textLength == 0) {
            customOpen('#filterBody');
        }
        else {
            $('#filterBody').removeClass('show');
        }
    });
});