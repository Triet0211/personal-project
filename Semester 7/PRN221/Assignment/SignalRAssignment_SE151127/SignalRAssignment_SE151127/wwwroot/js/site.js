$(() => {

    LoadPostData();
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();
    connection.on("LoadPosts", function () {
        LoadPostData();
    })

    LoadPostData();


    function LoadPostData() {
        var tr = '';
        $.ajax({
            url: '/Posts/GetPosts',
            method: 'GET',
            success: (result) => {
                console.log(result);
                for (const v of result) {
                    tr += ` <tr class = "table">
                                <td class = "title">${v.title}</td>
                                <td>${v.content}</td>
                                <td>${v.createdDate}</td>
                                <td>${v.updatedDate || "Not updated yet!"}</td>
                                <td>${v.publishStatus}</td>
                                <td>${v.author.email}</td>
                                <td>${v.category.categoryName}</td>
                                <td>
                                <a href='Posts/Details?id=${v.postId}'>Details</a>
                                `;
                    if (v.isLoggingIn) {
                        tr += `| <a href='Posts/Edit?id=${v.postId}'>Edit</a> | <a href='Posts/Delete?id=${v.postId}'>Delete</a> </td>
                            </tr > `
                    } else {
                        tr += `</td>
                            </tr > `
                    }
                }
                $("#tableBody").html(tr);
                filterPost();
            },
                error: (error) => {
                console.log(error)
            }
        });
    }
})

function filterPost() {
    var input, filter, cards, cardContainer, title, i;
    input = document.getElementById("myFilter");
    if (!input) return;
    filter = input.value.toUpperCase();
    cardContainer = document.getElementById("tableBody");
    cards = cardContainer.getElementsByClassName("table");
    for (i = 0; i < cards.length; i++) {
        title = cards[i].querySelector(".title");
        if (title.innerText.toUpperCase().indexOf(filter) > -1) {
            cards[i].style.display = "";
        } else {
            cards[i].style.display = "none";
        }
    }
}