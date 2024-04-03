import * as React from "react";
import "./PopupFlyoutView.scss";

interface  IPopupFlyoutViewProps {}
interface PopupFlyoutViewState {
    inputText: string;
}

export default class PopupFlyoutView extends React.Component<IPopupFlyoutViewProps, PopupFlyoutViewState>  {
    private readonly inputRef = React.createRef<HTMLInputElement>();

    constructor(props: IPopupFlyoutViewProps) {
        super(props);
        this.initialize();
    }

    private async initialize(): Promise<void> {
        this.state = {
            inputText: ""
        };
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(event : React.ChangeEvent<HTMLInputElement>) {
        this.setState({ inputText: event.target.value });
    }

    public render(): JSX.Element {
        return (
            <div className="poppup-view">
                THIS WILL ALWAYS APPEAR HAHAHAH
                <input className="flyout-input" value={this.state.inputText} onChange={this.handleChange} />
            </div>
        );
    }
}
