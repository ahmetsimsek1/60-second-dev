class Item {
    constructor(id, name) {
        this.id = id;
        this.name = name;
    }
}

document.addEventListener("DOMContentLoaded", () => {
    const data = {
        title: "My List (using script tags)",
        items: [
            new Item(1, "milk"),
            new Item(2, "cookies"),
            new Item(3, "lettuce")
        ],
        showLine: false
    };
    
    const itemTemplate = document.getElementById("item-template").innerHTML;
    const sectionTemplate = document.getElementById("section-template").innerHTML;
    
    const html = Mustache.render(sectionTemplate, data, {
        item: itemTemplate
    });
    document.getElementById("results").innerHTML = html;
});
