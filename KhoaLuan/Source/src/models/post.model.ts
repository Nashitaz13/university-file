import { Location } from './location.model';

export class Post {
    postId: string;
    authorId: string;
    authorName: string;
    title: string;
    category: number;
    contractType: number;
    location: Location;
    description: string;
    state: string;
    salary: number;
    unit: number;
    createdDate: string;
    dateExpired: string;
    distance: string;
    postViewCount: number;
    keyWord: string;
    type: string;
}   