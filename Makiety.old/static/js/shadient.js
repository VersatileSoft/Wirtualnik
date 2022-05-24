// Przycisk zmiany trybu kolorów między light, a dark
// ID "DarkModeToggle"
function DarkModeToggle() {
 const container = document.getElementById('Home');
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

// Wysuwane menu Sortowanie / Filtrowanie PC
// Zmienia wartość display: block/none dla ID sidebar
function sidebarMobileButton() {
  document.getElementById("sidebar");
  var x = document.getElementById("sidebar");
  var y = document.getElementById("Home");
  if (x.style.display === "block") {
    x.style.display = "none";

  } else {
    x.style.display = "block";
  }
}

// Przycisk usuwania koszyka w Polubionych wirtualnikach
// Zmienia wartość display: block/none dla ID deleteButton
function deleteButton() {
  document.getElementById("fullscreenModal");
  var x = document.getElementById("fullscreenModal");
  if (x.style.display === "block") {
    x.style.display = "none";

  } else {
    x.style.display = "block";
  }
}

// Tymczasowe gówno do chowania "Najpopularniejsze"
// Weź to wyjeb i zrób porządnie
function ShowPopularList() {
  document.getElementById("popular_items");
  var x = document.getElementById("popular_items");
  if (x.style.display === "none") {
    x.style.display = "block";

  } else {
    x.style.display = "none";
  }
}

// Przycisk usuwania koszyka w Polubionych wirtualnikach
// Zmienia wartość display: block/none dla ID deleteButton
function imageModal() {
  document.getElementById("imageModal");
  var x = document.getElementById("imageModal");
  if (x.style.display === "block") {
    x.style.display = "none";

  } else {
    x.style.display = "block";
  }
}


// Wysuwane menu Sortowanie / Filtrowanie mobile
// Zmienia wartość display: między block/none dla ID sidebar
// Dodatkowo przełącza wartośc overflow: auto/hidden dla ID Home aby
// zliwidowac problem z przesuwającym się głównym kontenerem pod wyskakującym oknem
const mediaQuery = window.matchMedia('(max-width: 720px)')
if (mediaQuery.matches) {
  function sidebarMobileButton() {
    document.getElementById("sidebar");
    var x = document.getElementById("sidebar");
    var y = document.getElementById("Home");
    if (x.style.display === "block") {
      x.style.display = "none";
      y.style.overflow = "auto";

    } else {
      x.style.display = "block";
      y.style.overflow = "hidden";
    }
  }
}
handleTabletChange(mediaQuery)


// Funkcjonalność przycisku menu użytkownika
// Działa pod ID "user-menu"
function UserMenuToggle() {
  document.getElementById("user-menu");
  var x = document.getElementById("user-menu");

  if (x.style.display === "block") {
    x.style.display = "none";

  } else {
    x.style.display = "block";
  }
}

// Funkcjonalność przycisku głównego menu
// Działa pod ID "big-menu"
function BigMenuToggle() {
  document.getElementById("big-menu");
  var x = document.getElementById("big-menu");

  if (x.style.display === "block") {
    x.style.display = "none";

  } else {
    x.style.display = "block";
  }
}
