<template>
  <div class="blog-feed">
    <div class="blog-feed__blog-post">
      <sub class="blog-feed__sub"> 🔥 Piotr Plenzler | 30.06.2021 </sub>
      <img
        src="~/assets/images/articles/ssd.jpg"
        class="blog-feed__img"
        alt="ssd"
      />
      <h3 class="blog-feed__title">
        <a href="#" class="blog-feed__anchor">
          A może SSD jednak powinno się defragmentować?
        </a>
      </h3>
      Defragmentacja dysku SSD rzekomo jest procesem, który wyłącznie szkodzi i
      psuje dyski SSD. Jednak czy te informacje są jeszcze prawdziwe? Czy TLC i
      QLC coś zmieniły w tej kwestii?
    </div>
    <div class="blog-feed__blog-post">
      <sub class="blog-feed__sub">Bartosz Batkowski | 27.06.2021</sub>
      <img
        src="~/assets/images/articles/ram.jpg"
        class="blog-feed__img"
        alt="ram"
      />
      <h3 class="blog-feed__title">
        <a href="#" class="blog-feed__anchor">
          Co jest ważniejsze w RAM - MHz czy CL?
        </a>
      </h3>
      Defragmentacja dysku SSD rzekomo jest procesem, który wyłącznie szkodzi i
      psuje dyski SSD. Jednak czy te informacje są jeszcze prawdziwe? Czy TLC i
      QLC coś zmieniły w tej kwestii?
    </div>
    <div class="blog-feed__blog-post">
      <sub class="blog-feed__sub"> Piotr Plenzler | 30.06.2021 </sub>
      <img src="~/assets/images/articles/ssd.jpg" class="blog-feed__img" />
      <h3 class="blog-feed__title">
        <a href="#" class="blog-feed__anchor">
          Wielki test darmowych antywirusów 2021
        </a>
      </h3>
      Defragmentacja dysku SSD rzekomo jest procesem, który wyłącznie szkodzi i
      psuje dyski SSD. Jednak czy te informacje są jeszcze prawdziwe? Czy TLC i
      QLC coś zmieniły w tej kwestii?
    </div>
    <center>
      <a href="https://wordpress.com/" class="btn-light" target="_blank">
        Więcej artykułów...
      </a>
    </center>
  </div>
</template>

<style lang="scss" scoped>
.blog-feed {
  margin: 0 8px;
  min-width: 300px;
  flex: 1 1 30%;
  &__blog-post {
    background-color: var(--semitransparent);
    border-radius: 10px;
    padding: 10px;
    margin-bottom: 40px;
    color: var(--gray6);
  }
  &__sub {
    display: block;
    float: right;
    color: var(--gray6);
    margin-top: -30px;
  }
  &__img {
    width: 100px;
    height: 100px;
    flex: 1 0 100px;
    margin: -10px 10px 0 -10px;
    float: left;
    border-radius: 10px 0 0 0;
  }
  &__anchor {
    text-decoration: underline;
    display: block;
    text-decoration-color: var(--gray3);
    transition: all 0.1s ease-out;
    color: inherit;
    &:hover {
      color: var(--red);
    }
  }
  &__title {
    margin-top: 0;
    margin-bottom: 5px;
    color: var(--black);
  }
}
</style>
