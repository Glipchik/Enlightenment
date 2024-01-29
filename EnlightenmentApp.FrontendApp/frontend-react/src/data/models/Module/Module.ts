import Tag from "../Tag/Tag";
import Section from "../Section/Section";
import ModuleReview from "../ModuleReview/ModuleReview";

export interface Module {
  id: number;
  title: string;
  author: string;
  rating: number;
  cost: number;
  summary: string;
  reviews: ModuleReview[] | null;
  tags: Tag[] | null;
  imageSrc: string;
  sections: Section[];
  isCompleted: boolean;
}
