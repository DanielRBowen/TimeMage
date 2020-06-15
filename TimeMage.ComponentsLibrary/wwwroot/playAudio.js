window.playAudio = {
    playBlob: function (blobData) {
        let blobUrl = URL.createObjectURL(new Blob(blobData, { type: 'application/octet-stream'}));
        var sound = new Howl({
            src: [blobUrl]
        });

        sound.play();
    }
};