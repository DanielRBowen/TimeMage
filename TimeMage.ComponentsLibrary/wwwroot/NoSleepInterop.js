// https://github.com/richtr/NoSleep.js/
const noSleep = new NoSleep();

function noSleepEnable() {
    // Enable wake lock.
    // (must be wrapped in a user input event handler e.g. a mouse or touch handler)
    document.addEventListener('click', function enableNoSleep() {
        document.removeEventListener('click', enableNoSleep, false);
        noSleep.enable();
    }, false);
}

function noSleepDisable() {
    // Disable wake lock at some point in the future.
    // (does not need to be wrapped in any user input event handler)
    noSleep.disable();
}
