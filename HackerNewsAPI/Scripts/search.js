let searchNews = () => {
    var _data = {
        StoryName: $("#needle").val()
    };
    console.log("searching...");
    $.ajax({
        url: '/Home/Search',
        type: "POST",
        data: JSON.stringify(_data),
        contentType: "application/json",
        dataType: "html",
        success: (results) => {
            $("#results").html(results);
        }
    });
}