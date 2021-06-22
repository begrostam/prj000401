function reg() {
    return new Promisel((resolve, reject) => {
        setTimeout(() => {
            const check = true;
            if (check) {
                const users = [
                    { name: 'namel' },
                    { name: 'name2' }
                ];
                resolve(users);
            } else {
                reject('NO');
            }
        }, 2000);
    });
}
reg().then((response) => {
    console.log(response);
    return 0;
}).
    then((response) => {
        console.log(response);
    })
    .catch((error) => {
        console.log(error);
    });
