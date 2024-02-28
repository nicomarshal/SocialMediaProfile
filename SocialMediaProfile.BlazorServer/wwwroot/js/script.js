function ScrollToSection(sectionId) {
    var section = document.getElementById(sectionId);
    section.scrollIntoView({ behavior: 'smooth' });
}
function ScrollToAboutMeSection() {
    var nav = document.getElementById("nav");
    var banner = document.getElementById("banner");

    var navHeight = nav.scrollHeight;
    var bannerHeight = banner.scrollHeight;

    var height = bannerHeight - navHeight - 145;

    window.scrollTo({ top: height, behavior: 'smooth' });
}
