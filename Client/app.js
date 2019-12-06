(function($){
    function processForm( e ){
        var dict = {
        	Title : this["title"].value,
            Director: this["director"].value,
            Genre: this["genre"].value,
            
        };

        $.ajax({
            url: 'https://localhost:44352/api/movie',
            dataType: 'json',
            type: 'Post',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function(data){
                WriteTable(data)

            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
            }
        });
        e.preventDefault();
    }

    $('#my-form').submit( processForm ); 

})(jQuery);
$(document).ready(GetAllMovies);
function GetAllMovies(){

    $.ajax({
        url: 'https://localhost:44352/api/movie',
        dataType: 'json',
        type: 'Get',
        contentType: 'application/json',
        success: function(data){
            console.log(data);
            WriteTable(data)
        },
        error: function( jqXhr, textStatus, errorThrown ){
            console.log( errorThrown );
        }
    });
}
function WriteTable(data){
    var result = "<table><th>Title</th><th>Director</th><th>Genre</th>";
    $.each(data, function(index, record){
        result += "<tr><td>" + record.Title + "</td><td>" + record.Director + "</td><td>&nbsp;" + record.Genre + "</td></tr>"
    });
    result += "</table>"
    $("#response pre").html(result);
}
