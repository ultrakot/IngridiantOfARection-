







function ShowResults()
{

    var input = document.getElementById("input");
    var res = document.getElementById("result");
    res.innerHTML = '';
   

    fetch("https://localhost:44313/fdadata/" + input.value)
    .then(function(data)
    {
        var json = data.json();
        console.log(json);
        return json;
       
    }).then(function(json){ 
        
        res.innerHTML += "<div class=\"row\" id=\"title-row\"><div class=\"col\">ingridiant</div><div class=\"col\">occurances</div><div class=\"col\">pracentage among occurances</div></div>";
        json.forEach(function(reactionObj){
            res.innerHTML += "<div class=\"row\"><div class=\"col\">" + reactionObj.IngredientName +"</div><div class=\"col\">" + reactionObj.AmountOfReactions +"</div><div class=\"col\">" + reactionObj.PracentageInGeneral +" ";
        });    
    });

}