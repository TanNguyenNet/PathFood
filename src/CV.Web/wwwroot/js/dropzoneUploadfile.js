Dropzone.autoDiscover = false;

$(function () {
    // Now that the DOM is fully loaded, create the dropzone, and setup the
    // event listeners
    var myDropzone = new Dropzone("#uploadFile", { url: "/api/setting/UploadFileAsync" });
    myDropzone.options.myAwesomeDropzone = {
        paramName: "file", // The name that will be used to transfer the file
        maxFilesize: 5,// MB
        maxFiles: 1, //Max file
        addRemoveLinks: true,
        dictRemoveFile: "Delete"
    };
    myDropzone.on("success", function (file, serverResponse) {
        $('#urlImage').val(serverResponse);
        console.log($('#urlImage').val());
    });

    myDropzone.on("addedfile", function (file) {
        var removeButton = Dropzone.createElement("<a>Remove file</a>");


        removeButton.addEventListener("click", function () {
            myDropzone.removeFile(file);
        });

        file.previewElement.appendChild(removeButton);
    });
});