
let isbn = document.getElementById("User_ISBN").value;
let result = parseInt(isbn, 10);

function getBookDetails() { 
    fetch(`https://www.googleapis.com/books/v1/volumes?q=isbn:${result}`)
        .then(function (res) {
            return res.json();
        })
        .then(function (result) {
            title = result.items[0].volumeInfo.title;
            description = result.items[0].volumeInfo.description;
            subtitle = result.items[0].volumeInfo.subtitle;
            authors = result.items[0].volumeInfo.authors;
            category = result.items[0].volumeInfo.categories;
            pageCount = result.items[0].volumeInfo.pageCount;
            publisher = result.items[0].volumeInfo.publisher;
            publishedDate = result.items[0].volumeInfo.publishedDate;
            rating = result.items[0].volumeInfo.averageRating;
            language = result.items[0].volumeInfo.language;
          
            document.querySelector(".details-name").textContent = title;
            document.querySelector(".details-subtitle").textContent = subtitle;
            document.querySelector(".details-author").textContent = authors;
            document.querySelector(".details-description").textContent = description;
            document.querySelector(".details-category").textContent = category;
            document.querySelector(".details-pageCount").textContent = pageCount;
            document.querySelector(".details-publisher").textContent = publisher;
            document.querySelector(".details-publishedDate").textContent = publishedDate;
            document.querySelector(".details-rating").textContent = rating
            document.querySelector(".details-language").textContent = language;
        }),
        function (error) {
            console.log(error);
        };
}
getBookDetails();

google.books.load();

function initialize() {
    var viewer = new google.books.DefaultViewer(document.getElementById('viewerCanvas'));
    let isbn = document.getElementById("User_ISBN").value;
    viewer.load(`ISBN:${result}`);
}

google.books.setOnLoadCallback(initialize);








