export default function getDataFromStorage<T>(key: string, fallback: T) {
    const data = localStorage.getItem(key);

    if(!data) {
        localStorage.setItem(key, JSON.stringify(fallback));
        return fallback;
    }

    return JSON.parse(data) as T;
}
