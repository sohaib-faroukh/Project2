// export const REQUIREDPATTERN=".*\\S+.*";
export const REQUIREDPATTERN="^[a-zA-Z1-9].*";

export const CitiesList=[
    {Id:1,value:"Damascus"},
    {Id:1,value:"Daraa"},
    {Id:1,value:"Swida"},
    {Id:1,value:"Halab"},
    {Id:1,value:"Lattakia"},
    {Id:1,value:"Tartus"},
    {Id:1,value:"Homs"},
    {Id:1,value:"Hama"},
    {Id:1,value:"Deir EL-Zor"},
    {Id:1,value:"Hasaka"},
    {Id:1,value:"Damascus Countryside"},
    {Id:1,value:"Halab Countryside"},
  
];


export const ROUTES: RouteInfo[] = [
    { path: '/dashboard', title: 'Dashboard', icon: 'ni-chart-bar-32 text-primary', class: '' },

    {
        path: 'URM', title: 'User Role Management', icon: 'ni-settings text-orange', class: '', items: [

            { path: '/users', title: 'Users', icon: 'ni-tv-2 text-primary', class: '' },
            { path: '/roles', title: 'Roles', icon: 'ni-planet text-blue', class: '' },

        ]
    },
    
    { path: '/customers', title: 'Customers', icon: 'ni-single-02 text-info', class: '' },

    { path: '/surveys', title: 'Surveys Management', icon: 'ni-single-02 text-info', class: '' },


    // { path: '/icons', title: 'Icons', icon: 'ni-planet text-blue', class: '' },
    // { path: '/maps', title: 'Maps', icon: 'ni-pin-3 text-orange', class: '' },
    // { path: '/user-profile', title: 'User profile', icon: 'ni-single-02 text-yellow', class: '' },
    // { path: '/tables', title: 'Tables', icon: 'ni-bullet-list-67 text-red', class: '' },
    // { path: '/login', title: 'Login', icon: 'ni-key-25 text-info', class: '' },
    // { path: '/register', title: 'Register', icon: 'ni-circle-08 text-pink', class: '' }
];




export declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
    items?: RouteInfo[];
}