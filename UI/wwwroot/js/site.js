
// init Bloodhound with Remote + Prefetch
var engine = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    prefetch: {
        url: window.location.href + 'Home/TypeaheadPrefetch/',
        //cache: true,
        transform: function (data) {
            var newData = [];
            data.forEach(function (item) {
                newData.push({ 'name': item });
            });
            return newData;
        }
    },
    remote: {
        url: window.location.href + 'Home/TypeaheadQuery/' + '?query=%QUERY',
        wildcard: '%QUERY'
    },
});

// init Typeahead
$('#search_product-text').typeahead(
    {
        minLength: 3,
        highlight: true
    },
    {
        name: 'products',
        source: engine,
        display: function (item) {
            console.log(item);
            return `${item.vendorCode} ${item.name}`;
        },
        limit: 5,
        templates: {
            suggestion: function (item) {
                console.log(item);
                return '<div class="p-3 bg-light hover">' + item.vendorCode + ' ' + item.name + '</div>';
            }
        }
    });