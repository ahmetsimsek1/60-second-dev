class Item {
    constructor(id, name) {
        this.id = id;
        this.name = name;
    }
}

document.addEventListener("DOMContentLoaded", () => {
    const data = {
        title: "My List (using javascript)",
        items: [
            new Item(1, "milk"),
            new Item(2, "cookies"),
            new Item(3, "lettuce")
        ],
        showLine: false,
        message1: "<b>Hello!</b>",
        message2: "<b>Good Day!</b>"
    };
    
    const itemTemplate = `
        <li>
            {{id}}: {{name}}
        </li>
    `;
    
    const sectionTemplate = `
        <h3>{{title}}</h3>
        <ul>
            {{#items}}
                {{> item}}
            {{/items}}
        </ul>
    
        {{#showLine}}<hr>{{/showLine}}
        {{^showLine}}not showing line{{/showLine}}
        <div>{{message1}}</div>
        <div>{{{message2}}}</div>
    `;
    
    const html = Mustache.render(sectionTemplate, data, {
        item: itemTemplate
    });
    document.getElementById("results").innerHTML = html;
});
