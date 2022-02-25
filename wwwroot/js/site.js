// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function() {
    var max_fields      = 10; //maximum input boxes allowed
    var wrapper   		= $(".input_fields_wrap"); //Fields wrapper
    var add_button      = $(".add_field_button"); //Add button ID
    
    var x = 1; //initlal text box count
    $(add_button).click(function(e){ //on add input button click
    e.preventDefault();
        if(x < max_fields){ //max input box allowed
            x++; //text box increment
            //$(wrapper).append('<div class="input-group mb-3"><select asp-items="BadgesListItems" name="badges[]"></select><div class="input-group-append"><button class="btn btn-outline-danger remove_field" type="button">Supprimer</button></div></div>'); //add input box
            const node = document.getElementById("selectModel");
            const clone = node.cloneNode(true);
            $(clone).append('<button class="btn btn-outline-danger remove_field" type="button">Supprimer</button>')
            $(wrapper).append(clone);
        }
    });
    
    $(wrapper).on("click",".remove_field", function(e){ //user click on remove text
        e.preventDefault();$(this).parent('div').remove(); x--;
    })
});