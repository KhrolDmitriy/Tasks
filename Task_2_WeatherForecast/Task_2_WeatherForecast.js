const searchButton = document.getElementById("search-button");
const searchInput = document.getElementById("search-input")
const citySpan = document.getElementById("city");
const temperatureSpan = document.getElementById("temperature");
const weatherSpan = document.getElementById("weather");

searchButton.onclick = getWeather;

function getWeather() {
    var url = 'http://api.openweathermap.org/data/2.5/weather?q=' + searchInput.value + '&APPID=0de398a7a74d95993f93e315894cf250';
	
	fetch(url)
        .then(function (value) {
            if(value.ok)
                return value.json();
            else
                alert("Error!");
        })
        .then(function (value) {
            citySpan.innerText = value.name;
            temperatureSpan.innerText = Math.round(value.main.temp - 273.15) + '°C';
            weatherSpan.innerText = value.weather[0].main;
        })
        .catch(alert);
}
