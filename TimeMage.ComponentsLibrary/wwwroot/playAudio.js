function b64toBlob(b64Data, contentType, sliceSize) {
    contentType = contentType || '';
    sliceSize = sliceSize || 512;

    const byteCharacters = atob(b64Data);
    const byteArrays = [];

    for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        const slice = byteCharacters.slice(offset, offset + sliceSize);

        const byteNumbers = new Array(slice.length);
        for (let i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }

        const byteArray = new Uint8Array(byteNumbers);

        byteArrays.push(byteArray);
    }

    return new Blob(byteArrays, { type: contentType });
}

window.playAudio = {
    // https://blazor-tutorial.net/knowledge-base/52136899/servir-archivos-incrustados-en-la-biblioteca--net-a-html-en-blazor
    play: function (str64) {
        const blob = b64toBlob(str64, "audio/wav");
        const blobUrl = URL.createObjectURL(blob);
        const audio = new Audio(blobUrl);
        audio.currentTime = 0;
        audio.play();
    }
};