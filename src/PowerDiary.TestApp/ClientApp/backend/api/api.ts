export * from './chatArchive.service';
import { ChatArchiveService } from './chatArchive.service';
export * from './chatEventTypes.service';
import { ChatEventTypesService } from './chatEventTypes.service';
export const APIS = [ChatArchiveService, ChatEventTypesService];
