function checkCashRegister(price, cash, cid) {

    const status = {
        insufficientFunds: "INSUFFICIENT_FUNDS",
        closed: "CLOSED",
        open: "OPEN"
    };

    const valueOfOneCoinOrBill = [
        ["PENNY", 0.01],
        ["NICKEL", 0.05],
        ["DIME", 0.1],
        ["QUARTER", 0.25],
        ["ONE", 1],
        ["FIVE", 5],
        ["TEN", 10],
        ["TWENTY", 20],
        ["ONE HUNDRED", 100]
    ];

    const multiplier = 1000; // who doesn't love floating point arithmetic?
    const changeDue = (cash - price) * multiplier;
    const totalCashInDrawer = cid.reduce((total, current) => total + current[1], 0) * multiplier;

    const flatCid = cid.reduce((accumulator, currentItem) => {
        const valueOfCurrentCoinOrBill = valueOfOneCoinOrBill.filter(coinOrBill => coinOrBill[0] === currentItem[0])[0][1];
        const numberOfCoinsOrBills = Math.round(currentItem[1] / valueOfCurrentCoinOrBill);
        const coinOrBillToValue = [currentItem[0], valueOfCurrentCoinOrBill * multiplier];
        return accumulator.concat(Array.from(Array(numberOfCoinsOrBills), () => coinOrBillToValue));
    }, []).reverse();

    const getIndexOfCoinOrBillInChangeCollector = (changeCollector, currentCoinOrBill) => changeCollector.change.findIndex(item => item[0] === currentCoinOrBill);

    if (changeDue > totalCashInDrawer) {
        return {
            status: status.insufficientFunds,
            change: []
        }
    } else if (changeDue === totalCashInDrawer) {
        return {
            status: status.closed,
            change: cid
        }
    } else {

        let changeCollector = {change: []};

        for (let coinOrBill in flatCid) {
            const [currentCoinOrBill, currentValue] = flatCid[coinOrBill];
            let indexOfCoinOrBillInChangeCollector = getIndexOfCoinOrBillInChangeCollector(changeCollector, currentCoinOrBill);

            // add current value first
            if (indexOfCoinOrBillInChangeCollector < 0) {
                changeCollector.change.push([currentCoinOrBill, currentValue]);
                indexOfCoinOrBillInChangeCollector = getIndexOfCoinOrBillInChangeCollector(changeCollector, currentCoinOrBill);
            } else {
                changeCollector.change[indexOfCoinOrBillInChangeCollector][1] += currentValue;
            }

            const changeCollectorTotal = changeCollector.change.reduce((total, current) => total + current[1], 0);

            // then compare change due with change collector total
            if (changeDue < changeCollectorTotal) {
                changeCollector.change[indexOfCoinOrBillInChangeCollector][1] -= currentValue
            }

            if (changeDue === changeCollectorTotal) {
                return {
                    status: changeDue === totalCashInDrawer ? status.closed : status.open,
                    change: changeCollector.change
                                        .filter(item => item[1] > 0)
                                        .map(item => [item[0], item[1] / multiplier])
                }
            }
        }

        return { // default: we have cash in drawer but there's no combination of bills or coins that would be equal to change due
            status: status.insufficientFunds,
            change: []
        }
    }
}

console.log(checkCashRegister(3.26, 100, [["PENNY", 1.01], ["NICKEL", 2.05], ["DIME", 3.1], ["QUARTER", 4.25], ["ONE", 90], ["FIVE", 55], ["TEN", 20], ["TWENTY", 60], ["ONE HUNDRED", 100]]));
