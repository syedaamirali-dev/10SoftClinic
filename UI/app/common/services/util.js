var utilities = {
    formatDate: (dateStr) => {
        let date = new Date(dateStr);
        date = date.toString().split(" ");
        return date[1] + " " + date[2] + ", " + date[3];
    },
    formatTime: (dateTimeStr) => {
        let date = new Date(dateTimeStr);
        date = date.toString().split(" ");
        return date[4]
    },
    formatDateTime: (dateTimeStr) => {
        return `${utilities.formatDate(dateTimeStr)} @ ${utilities.formatTime(dateTimeStr)}`
    },
    slugify: (text) => {
        if (!text) {
            return "";
        }
        return text.toString().toLowerCase()
            .replace(/\s+/g, '-')           // Replace spaces with -
            .replace(/[^\w\-]+/g, '')       // Remove all non-word chars
            .replace(/\-\-+/g, '-')         // Replace multiple - with single -
            .replace(/^-+/, '')             // Trim - from start of text
            .replace(/-+$/, '');            // Trim - from end of text
    },
    viewDriveImage: (url) => {
        if (url.startsWith("https://drive.google.com")) {
            return url.replace("open", "uc")
        }
        return url;
    }
};