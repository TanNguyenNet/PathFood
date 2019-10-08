
$(function () {
    var $summernotes = $('[data-plugins="summernote"]');

    $.ajax({
        url: 'http://asset.sascenter.net/emojis.json',
        method: 'GET',
        async: false
    }).then(function (data) {
        window.emojis = Object.keys(data);
        window.emojiUrls = data;
    });

    $.each($summernotes,
        function (i, ele) {
            var $ele = $(ele);

            $ele.summernote('destroy');

            var height = $ele.data("summernote-height") || 400;

            $ele.summernote({
                height: height,
                placeholder: $ele.attr('placeholder') || "Viết nội dung tại đây...",
                codemirror: {
                    theme: 'monokai'
                },
                toolbar: [
                    // https://summernote.org/deep-dive/#custom-toolbar-popover
                    // [groupName, [list of button]]
                    ['para', ['style', 'ul', 'ol', 'paragraph']],
                    ['color', ['color']],
                    ['style', ['bold', 'italic', 'underline', 'clear']],
                    ['font', ['strikethrough']],
                    ['insert', ['link', 'picture', 'video', 'table', 'hr']],
                    ['view', ['fullscreen', 'codeview', 'help']]
                ],
                popover: {
                    image: [
                        ['image', ['resizeFull', 'resizeHalf', 'resizeQuarter', 'resizeNone']],
                        ['float', ['floatLeft', 'floatRight', 'floatNone']],
                        ['remove', ['removeMedia']]
                    ],
                    link: [
                        ['link', ['linkDialogShow', 'unlink']]
                    ],
                    table: [
                        ['add', ['addRowDown', 'addRowUp', 'addColLeft', 'addColRight']],
                        ['delete', ['deleteRow', 'deleteCol', 'deleteTable']],
                    ],
                    air: [
                        ['color', ['color']],
                        ['font', ['bold', 'underline', 'clear']],
                        ['para', ['ul', 'paragraph']],
                        ['table', ['table']],
                        ['insert', ['link', 'picture']]
                    ]
                },
                callbacks: {
                    onImageUpload: function (images) {
                        for (var i = 0; i < images.length; i++) {
                            var image = images[i];
                            var data = new FormData();
                            data.append("file", image);
                            $.ajax({
                                url: '/api/setting/UploadFileAsync',
                                cache: false,
                                contentType: false,
                                processData: false,
                                data: data,
                                type: "post",
                                success: function (serverResponse) {
                                    var imageUrl = serverResponse;

                                    console.log(imageUrl);

                                    $ele.summernote("insertNode", $('<img>').attr('src', imageUrl)[0]);
                                },
                                error: function (data) {
                                    console.log(data);
                                }
                            });
                        }
                    },
                },
                lang: 'vi-VN',
                hint: {
                    match: /:([\-+\w]+)$/,
                    search: function (keyword, callback) {
                        callback($.grep(emojis, function (item) {
                            return item.indexOf(keyword) === 0;
                        }));
                    },
                    template: function (item) {
                        var content = emojiUrls[item];
                        return '<img src="' + content + '" width="20" /> :' + item + ':';
                    },
                    content: function (item) {
                        var url = emojiUrls[item];
                        if (url) {
                            return $('<img />').attr('src', url).css('width', 20)[0];
                        }
                        return '';
                    }
                }
            });
        });
});