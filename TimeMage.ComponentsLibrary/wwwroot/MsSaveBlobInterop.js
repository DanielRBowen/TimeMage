window.msSaveBlob = function (payload, encode = false, filename = 'file.xlsx', type = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet') {
    let createBlob = null;

    if (encode == true) {
        createBlob = data => {

            // base64 string
            var base64str = payload;

            // decode base64 string, remove space for IE compatibility
            var binary = atob(base64str.replace(/\s/g, ''));
            var len = binary.length;
            var buffer = new ArrayBuffer(len);
            var view = new Uint8Array(buffer);
            for (var i = 0; i < len; i++) {
                view[i] = binary.charCodeAt(i);
            }

            // create the blob object with content-type             
            var blob = new Blob([view], { type: type });
            var url = URL.createObjectURL(blob);
            return blob;
        };
    } else {
        createBlob = data => new Blob([data], { type: type });
    }

    const buildDownloadLink = (blob, fileName) => {
        let link = document.createElement("a");
        link.setAttribute("href", URL.createObjectURL(blob));
        link.setAttribute("download", fileName);
        link.style = "visibility:hidden";
        return link;
    };

    const invokeDownload = link => {
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    };

    const isHtmlDownloadAllowed = document.createElement("a").download !== undefined;
    const isSaveBlobAllowed = navigator.msSaveBlob;

    isSaveBlobAllowed ? navigator.msSaveBlob(createBlob(payload), filename) :
        isHtmlDownloadAllowed ? invokeDownload(buildDownloadLink(createBlob(payload), filename)) :
            console.log("Feature unsupported");
};