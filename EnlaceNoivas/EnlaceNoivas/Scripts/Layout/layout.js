$(document)
    .on('change', '.btn-file :file', function() {
        var input = $(this),
            numFiles = input.get(0).files ? input.get(0).files.length : 1,
            label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
        input.trigger('fileselect', [numFiles, label]);
});
$(document).ready(function () {
    $('.btn-file :file').on('fileselect', function (event, numFiles, label) {
        console.log(numFiles);
        console.log(label);
        $('#file-text').val(label);
    });
    $("#search-field").autocomplete({
        max:5,
        source: function (request, response) {
            $.ajax({
                url: "/Search/Found",
                data: { searched: $("#search-field").val() },
                type: "POST",
                dataType: "json",
                success: function (data) {
                    response($.map(data, function (item) {
                        
                        return { label: item.Id, value: item.Name, image: item.ImagePath, city: item.City, street: item.Street, number: item.Number};
                    }))

                }
            })
        },
        messages: {
            noResults: "", results: ""
        }
    }).data( "autocomplete" )._renderItem = function( ul, item ) {
        //var inner_html = '<a><div class="list_item_container"><div class="label">' + item.label + '</div></div><div class="label">' + item.city + '</div></div><div class="label">' + item.street + ', '+item.number+'</div></div></a>';
        //var innet_html = '<a><div class="row"><div class="col-lg-2"><div class="image"><img width="70px" height="75px" src="' + item.image + '"></div></div><div class="row">  </div></div></a>'
        var inner_html = '<a><div class="row"></div><div class="col-lg-4" id="image"><img width="70" height="75" src="' + item.image + '"/></div><div class="col-lg-8"><div class="row"><h4>' + item.label + '</h4></div><div class="row"><p>' + item.city + '</p><p>' + item.street + ' ,' + item.number + '</p></div></div></a>';
        return $("<li></li>")
            .data( "item.autocomplete", item )
            .append(inner_html)
            .appendTo( ul );
    };
});