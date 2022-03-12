export const AVATAR = "https://cdn-icons-png.flaticon.com/512/147/147144.png"
export const BACKGROUND = "https://images.wallpaperscraft.com/image/single/forest_trees_fog_110131_1920x1080.jpg"

export type SUB_SECTION = {
    id: string,
    name: string,
    description: string,
}

export type SECTION = {
    name: string,
    subSections: SUB_SECTION[]
}

export type TOPIC = {
    id: string,
    subsectionId: string,
    name: string,
    description: string,
}

export type SUBJECT_POST = {
    id: string,
    topicId: string,
    author: string,
    date: Date,
    content: string,
}

export const SECTIONS: SECTION[] = [
    {
        name: "Nulla imperdiet",
        subSections: [
            {
                id: '1',
                name: "Lorem Ipsum",
                description: "Contrary to popular belief, Lorem Ipsum is not simply random text."
            },
            {
                id: '2',
                name: "Contrary to popular",
                description: "There are many variations of passages of Lorem Ipsum available."
            },
            {
                id: '3',
                name: "The standard chunk",
                description: "All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary."
            },
        ]
    },
    {
        name: "Etiam id dapibus",
        subSections: [
            {
                id: '4',
                name: "Orci varius",
                description: "Fusce ut ligula non sapien tincidunt condimentum id quis neque."
            },
            {
                id: '5',
                name: "Aliquam ut dui",
                description: "Aenean in gravida justo. Donec in justo diam."
            },
            {
                id: '6',
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
                id: '7',
                name: "",
                description: "Contrary to popular belief, Lorem Ipsum is not simply random text."
            },
        ]
    },
    {
        name: "Contrary to popular",
        subSections: [
            {
                id: '8',
                name: "",
                description: "There are many variations of passages of Lorem Ipsum available."
            },
        ]
    },
    {
        name: "The standard chunk",
        subSections: [
            {
                id: '9',
                name: "",
                description: "All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary."
            },
        ]
    },
]

export const TOPICS: TOPIC[] = Array.from(Array(20).keys()).map((num) => {
    return {
        id: (num + 1) + '',
        subsectionId: '1',
        name: "Example topic " + (num + 1),
        description: "Example topic description " + (num + 1)
    }
})

export const SUBJECT_POSTS: SUBJECT_POST[] = Array.from(Array(20).keys()).map((num) => {
    return {
        id: (num + 1) + '',
        topicId: '1',
        author: 'Author' + (num + 1),
        date: new Date(),
        content: 'All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary.'
    }
})