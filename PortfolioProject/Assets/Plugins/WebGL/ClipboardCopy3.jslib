mergeInto(LibraryManager.library, {
    CopyToClipboard: function(strPtr, strLen) {
        var str = UTF8ToString(strPtr, strLen);
        navigator.clipboard.writeText(str).then(function() {
            console.log('Copied to clipboard: ' + str);
        });
    }
});
