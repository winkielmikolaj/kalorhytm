// Modern Calendar JavaScript helpers
window.scrollCalendarToDate = (element, position) => {
    if (element && element.scrollTo) {
        element.scrollTo({
            left: position,
            behavior: 'smooth'
        });
    }
};

window.scrollCalendarByAmount = (element, amount) => {
    if (element) {
        const currentScroll = element.scrollLeft || 0;
        const newScroll = currentScroll + amount;
        element.scrollTo({
            left: newScroll,
            behavior: 'smooth'
        });
    }
};

window.scrollCalendarToCenter = (element, dayIndex) => {
    if (element) {
        // Find the button element for the selected day
        const buttons = element.querySelectorAll('button');
        if (buttons && buttons[dayIndex]) {
            const selectedButton = buttons[dayIndex];
            const containerWidth = element.offsetWidth;
            const buttonLeft = selectedButton.offsetLeft;
            const buttonWidth = selectedButton.offsetWidth;
            
            // Calculate scroll position to center the button
            const scrollPosition = buttonLeft - (containerWidth / 2) + (buttonWidth / 2);
            
            element.scrollTo({
                left: Math.max(0, scrollPosition),
                behavior: 'smooth'
            });
        }
    }
};

