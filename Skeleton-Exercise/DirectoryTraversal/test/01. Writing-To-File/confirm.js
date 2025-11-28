let r = confirm("Готові гризти граніт науки?");
if (r == true) {
    myTxt.innerHTML = "ВПЕРЕД ДО ЗНАНЬ!";
} else {
    myTxt.innerHTML = "Мені дуже сумно!";
}
let myImage = document.querySelector('img');
let j = 0;
myImage.onclick = function () {
    j++;
    let mySrc = myImage.getAttribute('src');
    if (mySrc === 'images/firefox-icon.png') {
        myImage.setAttribute('src', 'images/firefox-icon_bw.png');
    } else {
        myImage.setAttribute('src', 'images/firefox-icon.png');
    }
    if (r === true) {
        myTxt.innerHTML = "ВПЕРЕД ДО ЗНАНЬ!";
    } else {
        myTxt.innerHTML = "Мені дуже сумно!";
    }
    if (j === 3) {
        myImage.remove();
        document.write("<h1>Вітаю!</h1><h2>Завдання виконано!</h2>");
    }
}
myTxt.innerHTML += "<br>" + "  Клацніть мишею по емблемі FireFox!";
