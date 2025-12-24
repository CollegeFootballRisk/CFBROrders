//#region Light Mode/ Dark Mode

window.setTheme = function (theme) {
    document.documentElement.setAttribute("theme", theme);
};
window.setTheme("dark");

//#endregion

//#region Branding

window.setBranding = (branding) => {
    const logo = document.querySelector('.navbar-brand img');

    if (!logo) return;

    let logoSrc = 'images/Branding Logos/logo-rainbow.svg';

    switch (branding) {
        case 'Goose':
            logoSrc = 'images/Branding Logos/logo-goose-white.svg';
            break;
        case 'Pizza':
            logoSrc = 'images/Branding Logos/logo-pizza-white.svg';
            break;
        case 'Classic':
            logoSrc = 'images/Branding Logos/logo-classic.svg';
            break;
        case 'Normal - White':
            logoSrc = 'images/Branding Logos/logo-white.svg';
            break;
        case 'Normal - Rainbow':
        default:
            logoSrc = 'images/Branding Logos/logo-rainbow.svg';
            break;
    }

    logo.src = logoSrc;
};

//#endregion

//#region Seasonal Background Effects
window.backgroundEffects = {
    startEffect: (options = {}) => {
        const existing = document.getElementById('backgroundEffect');

        if (existing) return;

        const canvas = document.createElement('canvas');
        canvas.id = 'backgroundEffect';
        Object.assign(canvas.style, {
            position: 'fixed',
            top: 0,
            left: 0,
            width: '100vw',
            height: '100vh',
            pointerEvents: 'none',
            zIndex: 0
        });
        document.body.appendChild(canvas);

        const ctx = canvas.getContext('2d');
        canvas.width = window.innerWidth;
        canvas.height = window.innerHeight;

        const {
            particleCount = 80,
            speed = 1.5,
            color = '#fff',
            imageSrc,
            size = 18,
            rotate = true,
            rotationSpeed = 0.01,
            straightFall = false
        } = options;

        let particleImage = null;
        let imageLoaded = false;

        if (imageSrc)
        {
            particleImage = new Image();
            particleImage.onload = () => { imageLoaded = true; };
            particleImage.src = imageSrc;
        }

        const particles = Array.from({ length: particleCount }, () => ({
            x: Math.random() * canvas.width,
            y: Math.random() * canvas.height,
            r: Math.random() * 4 + 1,
            vy: Math.random() * speed + 0.5,
            vx: straightFall ? 0 : Math.random() * 0.6 - 0.3,
            angle: rotate ? Math.random() * Math.PI * 2 : 0,
            spin: rotate ? (Math.random() - 0.5) * rotationSpeed : 0
        }));

        const drawParticle = (p) => {
            ctx.save();
            ctx.translate(p.x, p.y);
            ctx.rotate(p.angle);

            if (imageLoaded)
            {
                const aspect = particleImage.naturalWidth / particleImage.naturalHeight;
                const width = size * aspect;
                const height = size;
                ctx.drawImage(particleImage, -width / 2, -height / 2, width, height);
            }
            else 
            {
                ctx.fillStyle = color;
                ctx.beginPath();
                ctx.arc(0, 0, p.r, 0, Math.PI * 2);
                ctx.fill();
            }

            ctx.restore();
        };

        const update = () => {
            ctx.clearRect(0, 0, canvas.width, canvas.height);

            particles.forEach(p => {
                p.y += p.vy;
                p.x += straightFall ? 0 : p.vx + Math.sin(p.y * 0.01);

                if (rotate)
                {
                    p.angle += p.spin;
                }

                if (p.y > canvas.height + 20)
                {
                    p.y = -20;
                    p.x = Math.random() * canvas.width;
                }

                drawParticle(p);
            });

            requestAnimationFrame(update);
        };

        update();

        window.addEventListener('resize', () => {
            canvas.width = window.innerWidth;
            canvas.height = window.innerHeight;
        });
    },

    stopEffect: () => {
        const canvas = document.getElementById('backgroundEffect');

        if (canvas)
        {
            canvas.remove();
        }
    }
};

window.setSeasonalEffects = (effectName) => {
    window.backgroundEffects.stopEffect();

    const effectsConfig = {
        Winter: { particleCount: 60, imageSrc: 'images/Background Effects/snowflake.svg', speed: 2, size: 20, rotationSpeed: 0.1 },
        Valentines: { particleCount: 60, imageSrc: 'images/Background Effects/heart.svg', speed: 1, size: 20 },
        Spring: { particleCount: 60, imageSrc: 'images/Background Effects/raindrop.svg', speed: 1, size: 20, rotate: false, straightFall: true },
        Summer: { particleCount: 60, imageSrc: 'images/Background Effects/sun.svg', speed: 1, size: 15, rotationSpeed: 0.1 },
        Fall: { particleCount: 60, imageSrc: 'images/Background Effects/football.svg', speed: 1, size: 20, rotationSpeed: 0.1 },
        Halloween: { particleCount: 60, imageSrc: 'images/Background Effects/pumpkin.svg', speed: 1, size: 24, rotationSpeed: 0.1 },
        Thanksgiving: { particleCount: 60, imageSrc: 'images/Background Effects/turkey.svg', speed: 1, size: 25, rotate: false }
    };

    if (effectsConfig[effectName])
    {
        window.backgroundEffects.startEffect(effectsConfig[effectName]);
    }
};

//#endregion