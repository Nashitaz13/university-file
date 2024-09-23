import { Category } from './category.model';

export class Config {
    id: number;
    luong: number = 0;
    bankinh: number = 40;
    isLamThem: boolean;
    isBanThoiGian: boolean;
    isToanThoiGian: boolean;
    categories: Category[];
}