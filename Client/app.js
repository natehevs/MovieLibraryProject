(function($){
    function processForm( e ){
        var dict = {
        	Title : this["title"].value,
            Genre : this["director"].value,
        	Director: this["genre"].value
        };

        $.ajax({
            url: 'https://localhost:44352/api/movie',
            dataType: 'json',
            type: 'GET',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function( data ){
                WriteTable(data);
            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
            }
        });
        e.preventDefault();
    }
    $('#my-form').submit( processForm );

        function WriteTable(data){
            var result = "<table><th>Title</th><th>Director</th><th>Genre</th>";
            $.each(data, function (index, record) {
                result += "<tr><td>" + record.title + "</td><td>" + record.director + "</td><td>&nbsp;" + record.genre + "</td>"
            });
            result += "</table>"
            $("#response pre").html(result);
        }
        // function ShowMovie(movie){
        //     if (movie != null){
        //         var strResult += "<table><th>Title</th><th>Director</th><th>Genre</th>";
        //         str result += "</table>";
        //         $("#divResult").html(strResult);
        //     }
        //     else {
        //         $("#dicResult").html("No Results To Display");
        //     }
        // }

        
}

    
})(jQuery);