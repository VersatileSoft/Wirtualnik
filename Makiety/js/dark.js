// Przycisk zmiany trybu kolorów między light, a dark
// ID "DarkModeToggle"
function DarkModeToggle() {
 const container = document.getElementById('App');
  const buttonDarkMode = document.getElementById('DarkModeToggle');
  const dataTheme = container.getAttribute('data-theme');

  if(dataTheme === 'dark') {
    container.setAttribute('data-theme', 'light');
    buttonDarkMode.innerHTML = 'DARK MODE';
  } else {
    container.setAttribute('data-theme', 'dark');
    buttonDarkMode.innerHTML = 'LIGHT MODE';
  }
}

// Przycisk "Szukaj" pokazujący search boxa
// Zmienia wartość display: block/none dla ID deleteButton
function SearchBoxToggle() {
  document.getElementById("searchBox");
  var x = document.getElementById("searchBox");
  if (x.style.display === "flex") {
    x.style.display = "none";

  } else {
    x.style.display = "flex";
  }
}
