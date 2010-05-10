function onCheckboxClick(imgId,hdId)
{
    var imgObj  = document.getElementById(imgId);
    var hdIdObj = document.getElementById(hdId);
    if(hdIdObj.value == 'False') 
    {
        imgObj.src = '../images/checkbox_checked.png';
        hdIdObj.value = "True";		
    }
    else
    {
        imgObj.src = '../images/checkbox_unchecked.png';
        hdIdObj.value = "False";
    }            
}
