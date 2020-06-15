//Frome: https://developer.mozilla.org/en-US/docs/Web/API/Blob
function typedArrayToURL(typedArray, mimeType) {
    return URL.createObjectURL(new Blob([typedArray.buffer], { type: mimeType }))
}

window.playAudio = {
    playBlob: function (bytes) {
        let blobUrl = typedArrayToURL(bytes, 'audio/wav');
        var sound = new Howl({
            src: [blobUrl],
            ext: ['wav']
        });

        sound.play();
    }
};