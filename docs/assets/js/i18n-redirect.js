/*
 * Sends the visitor to their preferred documentation language.
 *
 * Target language = the manual choice they made before (stored), or, on a first
 * visit, their browser language. If that target differs from the page currently
 * shown, we switch to it. English is the default served at the site root, so this
 * is what brings a user who picked e.g. Spanish back to Spanish when they open the
 * root URL again.
 *
 * We never compute URLs by hand: we reuse the theme's own language-selector links
 * (a[hreflang]), which already resolve to the correct per-page URL for each locale.
 */
(function () {
  var LOCALES = ["en", "fr", "de", "es", "it", "pt"];
  var KEY = "mfsdocs-lang";

  // Remember a manual language choice (a click in the language selector).
  document.addEventListener("click", function (e) {
    var a = e.target && e.target.closest ? e.target.closest("a[hreflang]") : null;
    if (!a) return;
    var l = (a.getAttribute("hreflang") || "").slice(0, 2).toLowerCase();
    if (LOCALES.indexOf(l) !== -1) localStorage.setItem(KEY, l);
  });

  // Current page language (Material sets <html lang="xx">).
  var current = (document.documentElement.getAttribute("lang") || "en")
    .slice(0, 2)
    .toLowerCase();

  // Target = stored manual choice, else the browser's preferred built language.
  var target = localStorage.getItem(KEY);
  if (!target || LOCALES.indexOf(target) === -1) {
    target = null;
    var prefs = navigator.languages || [navigator.language || "en"];
    for (var i = 0; i < prefs.length; i++) {
      var code = String(prefs[i] || "").slice(0, 2).toLowerCase();
      if (LOCALES.indexOf(code) !== -1) {
        target = code;
        break;
      }
    }
  }

  // Nothing to do if we can't determine a target or we're already on it.
  if (!target || target === current) return;

  // Switch using the theme's own link for the target language.
  var link = document.querySelector('a[hreflang="' + target + '"]');
  if (link && link.href && link.href !== window.location.href) {
    window.location.replace(link.href);
  }
})();
