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
                        
                        return { label: item.Id, value: item.Name, image: item.ImagePath, city: item.City, type: item.Type};
                    }))

                }
            })
        },
        messages: {
            noResults: "", results: ""
        }
    }).data( "autocomplete" )._renderItem = function( ul, item ) {
        var inner_html = '<a><div class="row"></div><div class="col-lg-4" id="image"><img width="70" height="75" src="' + item.image + '"/></div><div class="col-lg-8"><div class="row"><h4>' + item.label + '</h4></div><div class="row"><p>' + item.city + '</p><p>' + item.type +'</p></div></div></a>';
        return $('<a href="/Provider/'+replaceAll(item.label," ","_")+'"><li></li></a>')
            .data( "item.autocomplete", item )
            .append(inner_html)
            .appendTo( ul );
    };
});
function replaceAll(text, charb, chara){
    while(text.indexOf(charb) >= 0) {
        text = text.replace(charb,chara);
    }
    return text;
}