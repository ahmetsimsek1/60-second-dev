class Item {
    constructor(id, name, options) {
        this.id = id;
        this.name = name;
        this.isImportant = !!options?.isImportant;
    }

    format() {
        return (text, render) => {
            if (this.isImportant) {
                return `<span style="color:red;">${render(text)}</span>`;
            }
            return render(text);
        };
    }
}


document.addEventListener("DOMContentLoaded", () => {
    const data = {
        title: "My List (with a function)",
        items: [
            new Item(1, "milk"),
            new Item(2, "cookies"),
            new Item(3, "lettuce"),
            new Item(4, "eggs", { isImportant: true })
        ],
        showLine: false
    };
    
    const itemTemplate = `
        <li>
            {{#format}}
                {{id}}: {{name}}
            {{/format}}
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
    `;
    
    const html = Mustache.render(sectionTemplate, data, {
        item: itemTemplate
    });
    document.getElementById("results").innerHTML = html;
});
