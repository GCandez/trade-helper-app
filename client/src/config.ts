import wretch from 'wretch';

export const API_URL = '/api' as string;
export const API = wretch().url(API_URL);


