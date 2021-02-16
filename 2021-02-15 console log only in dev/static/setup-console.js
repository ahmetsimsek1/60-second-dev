// This assumes that your development environment
// is on localhost, and everything else is production

// This requires URI.js

(() => {
    const isQueryString = URI.parseQuery(
        URI.parse(document.location.href).query).verbose === "1";
    const isLocalhost = URI(location.href).hostname() === "localhost";

    if (isQueryString || isLocalhost) {
        console.logVerbose = function() { console.log(...arguments); };
    } else {
        console.logVerbose = () => { };
    }
})();
