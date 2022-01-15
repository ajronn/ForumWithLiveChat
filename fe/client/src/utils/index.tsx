export const AVATAR = "https://cdn-icons-png.flaticon.com/512/147/147144.png"
export const BACKGROUND = "https://images.wallpaperscraft.com/image/single/forest_trees_fog_110131_1920x1080.jpg"

export type SUB_SECTION = {
    name: string,
    description: string,
}

export type SECTION = {
    name: string,
    subSections: SUB_SECTION[]
}

export const SECTIONS: SECTION[] = [
    {
        name: "Nulla imperdiet",
        subSections: [
            {
                name: "Lorem Ipsum",
                description: "Contrary to popular belief, Lorem Ipsum is not simply random text."
            },
            {
                name: "Contrary to popular",
                description: "There are many variations of passages of Lorem Ipsum available."
            },
            {
                name: "The standard chunk",
                description: "All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary."
            },
        ]
    },
    {
        name: "Etiam id dapibus",
        subSections: [
            {
                name: "Orci varius",
                description: "Fusce ut ligula non sapien tincidunt condimentum id quis neque."
            },
            {
                name: "Aliquam ut dui",
                description: "Aenean in gravida justo. Donec in justo diam."
            },
            {
                name: "Aenean in gravida",
                description: "Vestibulum ante ipsum primis in faucibus orci luctus."
            },
        ]
    },
]

export const SPECIAL_SECTIONS: SECTION[] = [
    {
        name: "Lorem Ipsum",
        subSections: [
            {
                name: "",
                description: "Contrary to popular belief, Lorem Ipsum is not simply random text."
            },
        ]
    },
    {
        name: "Contrary to popular",
        subSections: [
            {
                name: "",
                description: "There are many variations of passages of Lorem Ipsum available."
            },
        ]
    },
    {
        name: "The standard chunk",
        subSections: [
            {
                name: "",
                description: "All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary."
            },
        ]
    },
]