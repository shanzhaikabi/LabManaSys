import { MenuDataItem } from '@ant-design/pro-layout';
import { GlobalModelState } from './global';
import { DefaultSettings as SettingModelState } from '../../config/defaultSettings';
import { UserModelState } from './user';
import { StateType } from './login';
import { ChemicalListModelState } from '../pages/Query/ChemicalList/model';
import { WorkFlowListModelType } from '../pages/My/WorkFlowList/model';
import { WorkFlowDetailModelType } from '../pages/My/WorkFlowDetail/model';
import { PostDeclarationFormModelType } from '../pages/Post/DeclarationForm/model';
import { PostFinancialFormModelType } from '../pages/Post/FinancialForm/model';
import { PostClaimFormModelType, FormToProcessModelType, FinancialProcessModelType, ClaimProcessModelType, ClaimFormChemicalModelType, MyChemicalModelType } from 'umi';

export { GlobalModelState, SettingModelState, UserModelState };
export interface Loading {
  global: boolean;
  effects: { [key: string]: boolean | undefined };
  models: {
    global?: boolean;
    menu?: boolean;
    setting?: boolean;
    user?: boolean;
    login?: boolean;
    chemicalList?: boolean;
    workflowList?: boolean;
    currentWorkFlow?: boolean;
    postDeclarationForm?: boolean;
    postClaimForm?: boolean;
    myFormToProcess?: boolean;
  };
}

export interface ConnectState {
  global: GlobalModelState;
  loading: Loading;
  settings: SettingModelState;
  user: UserModelState;
  login: StateType;
  chemicalList: ChemicalListModelState;
  workflowList: WorkFlowListModelType;
  currentWorkFlowDetail: WorkFlowDetailModelType;
  postDeclarationForm: PostDeclarationFormModelType;
  postFinancialForm: PostFinancialFormModelType;
  postClaimForm: PostClaimFormModelType;
  myFormToProcess: FormToProcessModelType;
  declearationFormProcess: DeclarationProcessModelType;
  financialFormProcess: FinancialProcessModelType;
  claimFormProcess: ClaimProcessModelType;
  claimDetail: ClaimFormChemicalModelType;
  myChemical: MyChemicalModelType;
}

export interface Route extends MenuDataItem {
  routes?: Route[];
}
