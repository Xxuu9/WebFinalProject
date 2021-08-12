const cacheName = 'cache-v1';
const dynamicCache = 'dyn-cache-v1';
let urlsToCache = [
    '/',
    '/css/site.css',
    '/css/style.css'
];

self.addEventListener('install', (event) => {
    console.info('Service Worker Installing...');

    event.waitUntil(
        caches.open(cacheName)
            .then(function (cache) {
                console.log('Opened cache');
                return cache.addAll(urlsToCache);
            })
    );

    console.info('Caching Started...');
});



 