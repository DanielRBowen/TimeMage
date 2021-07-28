/*!
 * Simple audio player based on the original Howler.js Audio Player Demo
 * https://github.com/goldfire/howler.js/blob/master/examples/player/player.js
 */
/// <reference types="howler"/>
var audioPlayer;
var hapDotNet;
var PlaylistItem = /** @class */ (function () {
    function PlaylistItem(title, file) {
        this.title = title;
        this.file = file;
    }
    return PlaylistItem;
}());
var AudioPlayer = /** @class */ (function () {
    function AudioPlayer(playlist) {
        var _this = this;
        this.playlist = {};
        this.index = 0;
        playlist.forEach(function (item) {
            _this.playlist[item.id] = new PlaylistItem(item.title, item.file);
        });
    }
    AudioPlayer.prototype.play = function (index) {
        var _this = this;
        if (index === void 0) { index = 0; }
        var sound;
        console.log('playing id:' + index);
        if (index >= Object.keys(this.playlist).length) {
            console.log('track does not exist');
            return;
        }
        var data = this.playlist[index];
        // If we already loaded this track, use the current one.
        // Otherwise, setup and load a new Howl
        if (data.howl) {
            sound = data.howl;
        }
        else {
            sound = data.howl = new Howl({
                src: data.file,
                html5: true,
                onplay: function () {
                    // Start upating the progress of the track.
                    // We user this instead of timer in blazor code because it more optimized
                    requestAnimationFrame(_this.step.bind(_this));
                    hapDotNet.invokeMethodAsync('RaiseOnPlay', sound.duration());
                },
                onload: function () {
                    hapDotNet.invokeMethodAsync('RaiseOnLoad');
                },
                onend: function () {
                    hapDotNet.invokeMethodAsync('RaiseOnEnd');
                },
                onpause: function () {
                    hapDotNet.invokeMethodAsync('RaiseOnPause');
                },
                onstop: function () {
                    hapDotNet.invokeMethodAsync('RaiseOnStop');
                },
                onseek: function () {
                    // Start upating the progress of the track.
                    requestAnimationFrame(_this.step.bind(_this));
                    hapDotNet.invokeMethodAsync('RaiseOnSeek');
                }
            });
        }
        // Begin playing the sound.
        sound.play();
        // Keep track of the index we are currently playing.
        this.index = index;
        return sound.state();
    };
    AudioPlayer.prototype.pause = function () {
        // Get the Howl we want to manipulate.
        var sound = this.playlist[this.index].howl;
        // Puase the sound.
        sound.pause();
    };
    AudioPlayer.prototype.stop = function (index) {
        if (this.playlist[index].howl) {
            this.playlist[index].howl.stop();
        }
    };
    AudioPlayer.prototype.volume = function (val) {
        // Update the global volume (affecting all Howls).
        Howler.volume(val);
    };
    AudioPlayer.prototype.seek = function (per) {
        // Get the Howl we want to manipulate.
        var sound = this.playlist[this.index].howl;
        // Convert the percent into a seek position.
        if (sound.playing()) {
            sound.seek(sound.duration() * per);
        }
    };
    AudioPlayer.prototype.step = function () {
        // Get the Howl we want to manipulate.
        var sound = this.playlist[this.index].howl;
        // Determine our current seek position.
        var seek = sound.seek() || 0;
        if (typeof seek == 'number')
            hapDotNet.invokeMethodAsync('RaiseOnStep', seek);
        // If the sound is still playing, continue stepping.
        if (sound.playing()) {
            requestAnimationFrame(this.step.bind(this));
        }
    };
    return AudioPlayer;
}());
// Interop calls
function createPlayer(playlist, dotNetHelper) {
    hapDotNet = dotNetHelper;
    audioPlayer = new AudioPlayer(playlist);
}
function playHowl(index) {
    return audioPlayer.play(index);
}
function pauseHowl() {
    audioPlayer.pause();
}
function stopHowl(index) {
    audioPlayer.stop(index);
}
function seekHowl(position) {
    audioPlayer.seek(position);
}
function volumeHowl(vol) {
    audioPlayer.volume(vol);
}
//# sourceMappingURL=HowlerJsAudioPlayer.js.map